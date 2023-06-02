import styles from "./Search.module.css"
import React from "react"

function Search()
{

    return(
        <div className={styles.container}>
            <input type="text" placeholder={"Поиск хавчика"} className={styles.search_input}/>
            <input type="button" value={"Поиск"} className={styles.search_button} onClick={()=>console.log("sdgdgdgds")}/>
        </div>
    )
}

export default Search