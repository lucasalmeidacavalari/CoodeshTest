import { useEffect, useState } from 'react';
import axios from 'axios';
import './card.scss';
import config from '../../appsettings.json';
import { formatDate } from '../../util/fileUtil';
import Snackbar from '../SnackBar';

const Card = ({ CreatorId, AffiliatedId }: any) => {
  const [data, setData] = useState<any>();
  const [showSnackbar, setShowSnackbar] = useState(false);
  const apiUrl = config.ConfigSettings.DEFAULT;

  useEffect(() => {
    const getDados = async () => {
      setShowSnackbar(false);
      try {
        let response;
        if (CreatorId) {
          response = await axios.get(apiUrl + '/Transaction/' + CreatorId + ',Creator');
        } else if (AffiliatedId) {
          response = await axios.get(apiUrl + '/Transaction/' + AffiliatedId + ',Affiliated');
        } else {
          response = await axios.get(apiUrl + '/Transaction/' + AffiliatedId + ',All');
        }
        setData(response.data);
      } catch (error) {
        setShowSnackbar(true);
      }
    };

    getDados();
  }, [CreatorId, AffiliatedId, apiUrl]);

  if (data?.length) {
    const totalPrice = data.reduce((total: number, item: any) => total + item.price, 0);
    const formattedTotalPrice = totalPrice.toLocaleString('pt-BR', {
      style: 'currency',
      currency: 'BRL',
    });

    return (
      <div className="card-container">
        <div className="total-price">Valor total: {formattedTotalPrice}</div>
        <div className="cards-container">
          {data.map((item: any) => (
            <div className="card" key={item.transactionId}>
              <div className="card-header">
                {item.type === 1 && <h3>Venda Produtor</h3>}
                {item.type === 2 && <h3>Venda afiliado</h3>}
                {item.type === 3 && <h3>Comissão paga</h3>}
                {item.type === 4 && <h3>Comissão recebida</h3>}
              </div>
              <div className="card-body">
                <p>ID: {item.transactionId}</p>
                <p>Data: {formatDate(item.dateTransaction)}</p>
                <p>Preço: {item.price.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</p>
                {item.creator && <p>Produtor: {item.creator.name}</p>}
                {item.affiliated && <p>Afiliado: {item.affiliated.name}</p>}
                {item.product && <p>Produto: {item.product.name}</p>}
              </div>
            </div>
          ))}
        </div>

        {showSnackbar && (
          <Snackbar message="Não foi possivel encontrar transições!" duration={3000} />
        )}
      </div>
    );
  }

  return null;
};

export default Card;
