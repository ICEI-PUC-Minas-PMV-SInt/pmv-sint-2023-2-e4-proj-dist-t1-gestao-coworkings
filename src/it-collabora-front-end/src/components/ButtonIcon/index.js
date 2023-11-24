import './styles.css';

import { ReactComponent as ArrowIcon } from 'C:/Users/l.lopes/Downloads/PUC2/pmv-sint-2023-2-e4-proj-dist-t1-gestao-coworkings/src/it-collabora-front-end/src/assets/images/arrow.svg';


const ButtonIcon = () => {
  return (
    <div className="btn-container">
      <button className="btn btn-primary">
        <h6>Inicie a sua busca</h6>
      </button>
      <div className="btn-icon-container">
        <ArrowIcon/>
      </div>
    </div>
  );
};

export default ButtonIcon;