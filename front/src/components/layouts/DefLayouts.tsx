

import Navbar from "../navbar/Navbar";
import { Outlet } from "react-router";
const DefLayouts = () =>
    {
        return(
            <>
            <Navbar/>

                <Outlet />

            </>

        )
           
        }
    
export default DefLayouts;