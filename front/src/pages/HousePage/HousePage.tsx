import LinearProgress from "@mui/material/LinearProgress";
import { useGetHousesQuery } from "../../store/services/houseApi";
import Box from "@mui/material/Box";
import HouseCard from "../../components/cards/HouseCard";
import type { House } from "./types";


const HousePage = () =>{
    const { data, isLoading } = useGetHousesQuery(null);

    return(
        <>
            {isLoading ? (
                <LinearProgress color="secondary" />
            ):(
                <Box minHeight="200vh">
                    {data?.payload.map((house: House) => (
                        <HouseCard key={house.id} house={house} />
                    ))}
                </Box>
            )}
        </>

    );
};
    
export default HousePage;