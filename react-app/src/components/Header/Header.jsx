import styles from'./Header.module.css'
import {Link} from 'react-router-dom'

function Header(props)
{

    const menu = [
        {title:'sdf',
        url:'fds'},
        {title:'sdd',
        url:'fs'}
    ]

    return(
        <div className={styles.header}>
           
                <Link className={styles.header_logo} to={props.title}>{props.title}</Link>
            
            
            <div className={styles.header_menu}>
                {menu.map((item,idx)=>(
                    <Link key={`menu item ${idx}`} to={item.url}>{item.title}</Link>
                ))}
                
            </div>
        </div>
    )
}

export default Header