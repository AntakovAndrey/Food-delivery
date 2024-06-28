import { Link } from 'react-router-dom'
import styles from './Card.module.css'
import React from 'react'
import Map from '../Map/Map'

function Card(props){
    
    return(
            <div className={styles.container}>
                <Link to={`/restaurant/${props.id}`} className={styles.link}>
                    <div className={styles.image_container}>
                        <img src={props.src} alt={props.src}/>
                    </div>
                    <div className={styles.text_container}>
                        <h3 className={styles.title}>{props.title}</h3>
                        <p className={styles.categories_container}>
                            {
                                props.categories.map((item,idx)=>(
                                    item+' '
                                ))
                            }
                        </p>
                    </div>
                </Link>
            </div>
    )
}

export default Card