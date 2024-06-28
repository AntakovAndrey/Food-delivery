import React from "react"
import Sidebar from "./components/Sidebar/Sidebar";
import DashboardHeader from "./components/DashboardHeader/DashboardHeader";
import styles from "./Dashboard.module.css";

function Dashboard()
{




    
    return(
        <>
            <Sidebar/>
            <div className="content">
                <DashboardHeader/>
            </div>
        </>
    )
}
export default Dashboard;