import Header from "../components/Header/Header"
import styles from './Home.module.css'
import  Search  from "../components/Search/Search"
import Modal from "../components/Modal/Modal"
import React from "react"
import Map from "../components/Map/Map"
import HomePageContent from "../components/HomePageContent/HomePageContent"






function Home()
{
    

    return(
        <>
            <Header title='Главная'/>
            <div className={styles.search_container}>
                <Search/>
            </div>
            <HomePageContent/>
            <div className={styles.container}>
                
                
            </div>
            
        </>
    )
        
    
}

export default Home