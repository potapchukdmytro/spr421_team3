import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import { imagesUrl } from "../../env";
import type { House } from "../../pages/HousePage/types";

const HouseCard: React.FC<{house: House}> = ({house}) => {
    return(
        <Box>
            <Box display="flex" alignItems="center" my={3}>
                <Box
                    className='track-cover'
                    mx={1}
                    component="img"
                    src={`${imagesUrl}/${house.posterUrl ? house.posterUrl : "def.png"}`}
                    width={90}
                    height={90}
                />
                <Box mx={1}>
                    <Typography variant="h6">{house.address}</Typography>
                    <Typography>{house.pricePerNight}</Typography>
                </Box>
            </Box>
        </Box>
    );
};
export default HouseCard;