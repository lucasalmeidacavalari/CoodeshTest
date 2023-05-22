// Card.js

import './card.scss';

const Card = ({ tipo, data, produto, valor, vendedor }: any) => {
  return (
    <div className="card">
      <div className="card-header">{tipo}</div>
      <div className="card-body">
        <p>Data: {data}</p>
        <p>Produto: {produto}</p>
        <p>Valor: {valor}</p>
        <p>Vendedor: {vendedor}</p>
      </div>
    </div>
  );
};

export default Card;
