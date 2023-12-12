import React, { useState, useEffect } from "react";
import ProductCard from "../../components/SpaceCard";

const Catalog = () => {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    fetch("https://localhost:7261/api/Room")
      .then((response) => response.json())
      .then((data) => setProducts(data))
      .catch((error) => console.error("Erro ao obter produtos:", error));
  }, []);

  return (
    <div className="container my-4">
      <div className="row">
        {products.map((product) => (
          <div key={product.id} className="col-sm-6 col-lg-4 col-xl-3">
            <ProductCard product={product} />
          </div>
        ))}
      </div>
    </div>
  );
};

export default Catalog;
