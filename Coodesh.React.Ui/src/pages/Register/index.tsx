import './register.scss';
import { useState } from 'react';
import { Link } from 'react-router-dom';

export default function Register() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
  
    function handleRegister(e: any) {
      e.preventDefault();
      if (email !== '' && password !== '') {
        alert("Boa")
      } else {
        alert("Preencha os dados de acesso!");
      }
    }
  
    return (
      <div className="container-home" onSubmit={handleRegister}>
        <h1>Coodesh Test</h1>
        <span>Crie uma nova conta!</span>
  
        <form className='form-home'>
          <input type="email" placeholder='Digite seu email...' name="email" id="email" value={email} onChange={e => setEmail(e.target.value)} />
          <input type="password" placeholder='*****' name="password" id="password" value={password} onChange={e => setPassword(e.target.value)} />
          <button type="submit">Registrar</button>
        </form>
  
        <Link className='button-link' to={'/'}>
          Já possui uma conta? Faça login!
        </Link>
      </div>
    );
  }