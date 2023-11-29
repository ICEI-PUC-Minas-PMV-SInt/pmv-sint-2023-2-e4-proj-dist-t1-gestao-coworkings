import "./styles.css";
import SpacePrice from "../SpacePrice";

import SpaceImg from "../../assets/images/space-image.png";

const SpaceCard = () => {
  return (
    <div className="base-card product-card">
      <div className="card-top-container">
        <img src={SpaceImg} alt="Nome do espaço" />
      </div>
      <div className="card-bottom-container">
        <h6> nome produto </h6>
        <SpacePrice />
      </div>
    </div>
  );
};

export default SpaceCard;
