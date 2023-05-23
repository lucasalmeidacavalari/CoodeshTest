import { useEffect, useState } from 'react';
import axios from 'axios';
import config from '../../appsettings.json';
import Card from '../Card';
import './gridcard.scss';
import Snackbar from '../SnackBar';

export default function GridCard() {
  const apiUrl = config.ConfigSettings.DEFAULT;
  const [creator, setCreator] = useState<{ creatorId: number; name: string }[]>();
  const [affiliated, setAffiliated] = useState<{ affiliatedId: number; name: string }[]>();
  const [selectedValue, setSelectedValue] = useState('');
  const [cardToRender, setCardToRender] = useState<JSX.Element | null>(null);
  const [showSnackbar, setShowSnackbar] = useState(false);
  const [errorMessage, setErrorMessage] = useState('');



  useEffect(() => {
    function getDados() {
      setShowSnackbar(false);
      axios.get(apiUrl + '/Affiliated')
        .then(response => {
          setAffiliated(response.data);
        })
        .catch(error => {
          setShowSnackbar(true);
          setErrorMessage("Error ao tentar encontrar Afiliados");
        });
      axios.get(apiUrl + '/Creator')
        .then(response => {
          setCreator(response.data);
        })
        .catch(error => {
          setShowSnackbar(true);
          setErrorMessage("Error ao tentar encontrar Criadores");
        });
    }
    getDados();
  }, [apiUrl]);

  const handleSelectChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setSelectedValue(event.target.value);
  };

  useEffect(() => {
    if (selectedValue.startsWith('creator-')) {
      const creatorId = selectedValue.split('-')[1];
      setCardToRender(<Card CreatorId={creatorId} />);
    } else if (selectedValue.startsWith('affiliated-')) {
      const affiliatedId = selectedValue.split('-')[1];
      setCardToRender(<Card AffiliatedId={affiliatedId} />);
    } else {
      setCardToRender(<Card />);
    }
  }, [selectedValue]);

  return (
    <article>
      <div className="select-wrapper">
        <select value={selectedValue} onChange={handleSelectChange}>
          <option value="">Selecione um Afiliado/Produtor</option>
          {creator && creator.map(item => (
            <option key={item.creatorId} value={`creator-${item.creatorId}`}>{item.name}</option>
          ))}
          {affiliated && affiliated.map(item => (
            <option key={item.affiliatedId} value={`affiliated-${item.affiliatedId}`}>{item.name}</option>
          ))}
        </select>
      </div>
      <div className='card-container'>
        {cardToRender}
      </div>

      {showSnackbar && (
        <Snackbar message={errorMessage} duration={3000} />
      )}
    </article>
  );
}
