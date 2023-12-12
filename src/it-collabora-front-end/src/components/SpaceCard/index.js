import "./styles.css";
import SpacePrice from "../SpacePrice";

import SpaceImg from "../../assets/images/space-image.png";

const SpaceCard = ({ product }) => {
  return (
    <div className="base-card product-card">
      <div className="card-top-container">
        <img src={SpaceImg} alt="Nome do espaço" />
      </div>
      <div className="card-bottom-container">
        <h6>{product.name}</h6>
        <p>{product.description}</p>
        <p>Capacidade total de pessoas: {product.totalCapacity}</p>
        <SpacePrice price={product.price} />
      </div>
    </div>
  );
};
export default SpaceCard;
