import Header from "../components/Header/Header"
import styles from './Home.module.css'
import  Search  from "../components/Search/Search"
import Modal from "../components/Modal/Modal"
import React from "react"
import Map from "../components/Map/Map"
import HomePageContent from "../components/HomePageContent/HomePageContent"






function Home()
{
    const [isModal, setModal] = React.useState(false);
    

    return(
        <>
            <Header title='Главная'/>
            <div className={styles.search_container}>
                <Search/>
            </div>
            <button onClick={() => setModal(true)}>Click Here</button> 
            <Modal
                isVisible={isModal}
                title={process.env.REACT_APP_API_URL}
                content={<Map/>}
                footer={<button onClick={()=>setModal(false)}>Cancel</button>}
                onClose={() => setModal(false)}
            />

            <HomePageContent/>
            <div className={styles.container}>
                
                
            </div>
            
        </>
    )
        
    
}

export default Home