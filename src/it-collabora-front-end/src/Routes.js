import { BrowserRouter, Route, Routes } from 'react-router-dom'; 

import Home from './pages/Home';
import Catalog from './pages/Catalog';
import Navbar from './components/Navbar';

const MainRoutes = () => (
  <BrowserRouter>
    <Navbar />
    <Routes>
      <Route path="/" element={<Home />} /> 
      <Route path="/catalog" element={<Catalog />} /> 
    </Routes>
  </BrowserRouter>
);

export default MainRoutes;