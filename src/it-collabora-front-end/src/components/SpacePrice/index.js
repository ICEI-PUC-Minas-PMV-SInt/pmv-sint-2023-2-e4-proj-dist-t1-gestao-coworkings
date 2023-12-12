import React from "react";

const SpacePrice = ({ price }) => {
  return (
    <div className="product-price-container">
      <span>R$</span>
      <h4>{price.toFixed(2)}</h4>
    </div>
  );
};

export default SpacePrice;
