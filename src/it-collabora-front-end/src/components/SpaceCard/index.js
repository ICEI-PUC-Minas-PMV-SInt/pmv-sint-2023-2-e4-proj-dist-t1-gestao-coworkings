import './styles.css';
import SpacePrice from '../SpacePrice';

import SpaceImg from 'C:/Users/l.lopes/Downloads/PUC2/pmv-sint-2023-2-e4-proj-dist-t1-gestao-coworkings/src/it-collabora-front-end/src/assets/images/space-image.png';


const SpaceCard = () => {
    return (
        <div className="base-card product-card">
            <div className="card-top-container">
                <img src = {SpaceImg} alt = "Nome do espaço"/>
            </div>
            <div className="card-bottom-container">
                <h6> nome produto </h6>
                <SpacePrice/>
            </div>
        </div>
    );
}

export default SpaceCard;