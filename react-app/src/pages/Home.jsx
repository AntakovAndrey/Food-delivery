import Card from "../components/Card/Card"
import Header from "../components/Header/Header"
import styles from './Home.module.css'
import  Search  from "../components/Search/Search"
import Modal from "../components/Modal/Modal"
import React from "react"
import Map from "../components/Map/Map"

function Home()
{
    const [isModal, setModal] = React.useState(false);
    return(
        <>
            <div>
                <h1>dhgsdf</h1>
                <map name=""></map>
            </div>
            <Header title='Главная'/>
            
            <div className={styles.search_container}>
                <Search/>
            </div>

            <button onClick={() => setModal(true)}>Click Here</button> 
               
                
            <Modal
                isVisible={isModal}
                title="Modal Title"
                content={<Map/>}
                footer={<button onClick={()=>setModal(false)}>Cancel</button>}
                onClose={() => setModal(false)}
            />
            <div className={styles.container}>
                <Card src='https://w.forfun.com/fetch/c9/c92dcab37e861605cf785b0632948e61.jpeg?h=900&r=0.5' title='fsd' categories={['fsdfs','fsdfsd']}/>
                <Card src='https://w.forfun.com/fetch/c9/c92dcab37e861605cf785b0632948e61.jpeg?h=900&r=0.5' title='fsd' categories={['fsdfs','fsdfsd']}/>
                <Card src='https://w.forfun.com/fetch/c9/c92dcab37e861605cf785b0632948e61.jpeg?h=900&r=0.5' title='fsd' categories={['fsdfs','fsdfsd']}/>
                <Card src='https://w.forfun.com/fetch/c9/c92dcab37e861605cf785b0632948e61.jpeg?h=900&r=0.5' title='fsd' categories={['fsdfs','fsdfsd']}/>
                <Card src='https://w.forfun.com/fetch/c9/c92dcab37e861605cf785b0632948e61.jpeg?h=900&r=0.5' title='fsd' categories={['fsdfs','fsdfsd']}/>
                <Card src='https://w.forfun.com/fetch/c9/c92dcab37e861605cf785b0632948e61.jpeg?h=900&r=0.5' title='fsd' categories={['fsdfs','fsdfsd']}/>
                <Card src='https://w.forfun.com/fetch/c9/c92dcab37e861605cf785b0632948e61.jpeg?h=900&r=0.5' title='fsd' categories={['fsdfs','fsdfsd']}/>
                <Card src='https://w.forfun.com/fetch/c9/c92dcab37e861605cf785b0632948e61.jpeg?h=900&r=0.5' title='fsd' categories={['fsdfs','fsdfsd']}/>
                <Card src='https://w.forfun.com/fetch/c9/c92dcab37e861605cf785b0632948e61.jpeg?h=900&r=0.5' title='fsd' categories={['fsdfs','fsdfsd']}/>
                <Card src='https://w.forfun.com/fetch/c9/c92dcab37e861605cf785b0632948e61.jpeg?h=900&r=0.5' title='fsd' categories={['fsdfs','fsdfsd']}/>
                <Card src='https://w.forfun.com/fetch/c9/c92dcab37e861605cf785b0632948e61.jpeg?h=900&r=0.5' title='fsd' categories={['fsdfs','fsdfsd']}/>
            </div>
            
        </>
    )
        
    
}

export default Home