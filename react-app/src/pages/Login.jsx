import React, { useState } from "react";

function Login()
{
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    async function f()
    {
      
      
    }

    const handleSubmit = async (event) => {
      event.preventDefault();
      let user = {"email":email,"password":password}
      const response = await fetch('https://localhost:7123/User/authenticate', {
        method:"POST",
        mode:"cors",
        headers: {
          'Content-Type': 'application/json'
        },      
        body: JSON.stringify({
          email: email,
          password: password
        })
      });
      let data = await response.json();
      localStorage.setItem("email", data.email);
      localStorage.setItem("id", data.id);
      localStorage.setItem("cartId", data.email);
    };

  return(
    <form onSubmit={handleSubmit}>
        <div>
            <label htmlFor="email">Email:</label>
            <input type="email" id="email" value={email} onChange={(event) => setEmail(event.target.value)} />
        </div>
        <div>
            <label htmlFor="password">Пароль:</label>
            <input type="password" id="password" value={password} onChange={(event) => setPassword(event.target.value)} />
        </div>
        <button type="submit">Войти</button>
    </form>      
  );
}

export default Login;