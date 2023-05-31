import { Link } from 'react-router-dom'
import styles from './Card.module.css'
import React from 'react'
function Card(props){
    return(
            <div className={styles.container}>
                <Link to={props.title} className={styles.link}>
                    <div className={styles.image_container}>
                        <img src={props.src} alt='fsdff'/>
                    </div>
                    <div className={styles.text_container}>
                        <p className={styles.title}>{props.title}</p>
                        <p>
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