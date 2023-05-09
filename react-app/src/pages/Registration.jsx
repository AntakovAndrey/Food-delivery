

function Registration()
{
    return(
        <form action="">
            <h1>Регистрация</h1>
            <div className="input_line">
                <label>E-mail</label>
                <input type="text"/>
            </div>
            <div className="input_line">
                <label>Pass</label>
                <input type="password"/>
            </div>
            
            <button type="submit"></button>
        </form>
    );
}

export default Registration