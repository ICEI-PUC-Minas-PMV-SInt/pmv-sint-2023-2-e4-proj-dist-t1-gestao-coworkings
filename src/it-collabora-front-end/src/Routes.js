import { BrowserRouter, Route, Routes } from 'react-router-dom'; 

import Home from './pages/Home';
import Catalog from './pages/Catalog';
import Login from './pages/Login';
import Navbar from './components/Navbar';

const MainRoutes = () => (
  <BrowserRouter>
    <Navbar />
    <Routes>
      <Route path="/" element={<Home />} /> 
      <Route path="/catalog" element={<Catalog />} /> 
      <Route path="/login" element={<Login />} /> 
    </Routes>
  </BrowserRouter>
);

export default MainRoutes;