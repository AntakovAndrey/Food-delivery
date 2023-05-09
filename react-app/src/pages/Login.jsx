import {Link} from "react-router-dom";
function Login()
{
    return(
    <div>
        <form action="">

            <div className="input_line">
                <label>E-mail</label>
                <input type="text"/>
                
            </div>
            <div className="input_line">
                <label>Пароль</label>
                <input type="Пароль"/>
                
            </div>
            <button type="submit">Войти</button>
            <Link to="/register">Нет аккаунта, надо зарегаться</Link>
        </form>
    </div>
    );
}

export default Login