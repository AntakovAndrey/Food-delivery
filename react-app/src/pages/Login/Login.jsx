import React, { useState } from "react";
import { Link,useNavigate } from "react-router-dom";
import styles from "./Login.module.css"

function Login()
{
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
      try {
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
        if(response.ok)
        {
          let data = await response.json();
        localStorage.setItem("email", data.email);
        localStorage.setItem("id", data.id);
        localStorage.setItem("cartId", data.cartId);
        localStorage.setItem("role", data.role.name);
        navigate('/')
        }
      } catch (error) {
          console.log(error)
      }
    };

  return(
    <div className={styles.container}>
      <form className={styles.login_form} onSubmit={handleSubmit}>
        <div className={styles.title_container}>
          <h1>Авторизация</h1>
        </div>
        <div className={styles.inputs_container}>
        <div >
              <label htmlFor="email">Email:</label>
              <br/>
              <input type="email" id="email" value={email} onChange={(event) => setEmail(event.target.value)} />
          </div>
          <div>
              <label htmlFor="password">Пароль:</label>
              <br />
              <input type="password" id="password" value={password} onChange={(event) => setPassword(event.target.value)} />
          </div>
          <div className={styles.button_container}>
            <button type="submit" className={styles.submit_button}>Войти</button>
          </div>
          <div className={styles.link_container}>
            <Link to="/">На главную</Link>
          </div>
          <div className={styles.link_container}>
            <Link to="/register">Нет аккаунта, зарегистрироваться</Link>
          </div>
        </div>
          
      </form>   
    </div>
       
  );
}

export default Login;