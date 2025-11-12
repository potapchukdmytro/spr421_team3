import Container from "@mui/material/Container";
import Navbar from "../navbar/Navbar";
import { Outlet } from "react-router";
const DefLayouts = () =>
    {
        return(
            <>
            <Navbar/>
            <Container>
                <Outlet/>
            </Container>
            </>

        )
           
        }
    
export default DefLayouts;