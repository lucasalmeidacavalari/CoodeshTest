import { useState } from 'react';
import { Link } from 'react-router-dom';

import './home.scss';

export default function Home() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  function handleLogin(e: any) {
    e.preventDefault();
    if (email !== '' && password !== '') {
      alert("Boa")
    } else {
      alert("Preencha os dados de acesso!");
    }
  }

  return (
    <div className="container-home" onSubmit={handleLogin}>
      <h1>Coodesh Test</h1>
      <span>Aplicação para exportação e parsing de arquivo</span>

      <form className='form-home'>
        <input type="email" placeholder='Digite seu email...' name="email" id="email" value={email} onChange={e => setEmail(e.target.value)} />
        <input type="password" placeholder='*****' name="password" id="password" value={password} onChange={e => setPassword(e.target.value)} />
        <button type="submit">Acessar</button>
      </form>

      <Link className='button-link' to={'/register'}>
        Não possui uma conta ? Cadastra-se!
      </Link>
    </div>
  );
}