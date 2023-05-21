import { Routes, Route } from 'react-router-dom';
import Login from '../pages/Login';
import Register from '../pages/Register';
import Home from '../pages/Home';

import Private from './Private';

export default function RoutesApp() {
  return (
    <Routes>
      <Route path="/" element={<Login />} />
      <Route path='/register' element={<Register />} />

      <Route path='/home' element={<Private> <Home /> </Private>} />

    </Routes>
  );
}

