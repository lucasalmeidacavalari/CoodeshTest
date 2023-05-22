import { useEffect, useState } from 'react';
import axios from 'axios';
import config from '../../appsettings.json';
import Card from '../Card';
import './gridcard.scss'

export default function GridCard() {
  const apiUrl = config.ConfigSettings.DEFAULT;
  const [creator, setCreator] = useState<{ creatorId: number, name: string }[]>();
  const [affiliated, setAffiliated] = useState<{ affiliatedId: number, name: string }[]>();
  const [selectedValue, setSelectedValue] = useState('');

  function getDados() {
    axios.get(apiUrl + '/Affiliated')
      .then(response => {
        setAffiliated(response.data);
      })
      .catch(error => {
        alert(error);
      });
    axios.get(apiUrl + '/Creator')
      .then(response => {
        setCreator(response.data);
      })
      .catch(error => {
        alert(error);
      });
  }

  useEffect(() => {
    getDados();
  }, []);

  const handleSelectChange = (event: any) => {
    setSelectedValue(event.target.value);
  };

  return (
    <article>
      <div className="select-wrapper">
        <select value={selectedValue} onChange={handleSelectChange}>
          <option value="">Selecione um Afiliado/Produtor</option>
          {creator && creator.map(item => (
            <option key={item.creatorId} value={item.creatorId}>{item.name}</option>
          ))}
          {affiliated && affiliated.map(item => (
            <option key={item.affiliatedId} value={item.affiliatedId}>{item.name}</option>
          ))}
        </select>
      </div>
      <Card
        tipo="Tipo do Card"
        data="Data do Card"
        produto="Produto do Card"
        valor="Valor do Card"
        vendedor="Vendedor do Card"
      />
    </article>
  );
}
