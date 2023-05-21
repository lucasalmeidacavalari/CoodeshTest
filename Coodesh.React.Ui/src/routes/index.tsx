import { Routes, Route } from 'react-router-dom';
import Home from '../pages/Home';
import Register from '../pages/Register';
import Dashbord from '../pages/Dashbord';

export default function RoutesApp() {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path='/register' element={<Register />} />

      <Route path='/dashbord' element={<Dashbord />} />

    </Routes>
  );
}

