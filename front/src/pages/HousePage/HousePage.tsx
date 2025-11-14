
import { useGetHousesQuery } from "../../store/HouseAPI";
import { fotoUrl} from '../../env';
import './HousePage.css';
import Box from "@mui/material/Box";
import { Link } from "react-router";
import { useDispatch } from "react-redux";

import { houseset} from '../../store/slices/houseSlice';
const HousePage = () =>{

const {data} = useGetHousesQuery(null)
const dispatch = useDispatch();

type House = {
  address: string;
  amountOfRooms: number;
  pricePerNight: number;
  posterUrl: string;
  isAvialable: boolean;
  ownerId: string;
};
    
        return(
            <>
            
            <Link
           
      to={`/housebooking`}>
            <div

          
  style={{
    display: "flex",
    flexWrap: "wrap",   
    gap: "20px",           
    justifyContent: "center",
    

  }}
> {data?.payload.map((p: House,index:number)=>(
      

      
       
        <Box    onClick={() => dispatch(houseset(p))}
        
          key={index}
          sx={{
        flex: "0 0 calc(50% - 10px)",
        maxWidth: "calc(50% - 10px)",
        display: "flex",
        flexDirection: "column",
        padding: "20px",
        border: "1px solid #ccc",
        borderRadius: "8px",
        boxShadow: "0 2px 8px rgba(0,0,0,0.1)",
        gap: "16px",
        alignItems: "flex-start",
        marginBottom: "24px",
        boxSizing: "border-box",
        backgroundColor :"rgba(76, 71, 71, 0.1)",
         transition: "transform 0.5s ease, box-shadow 0.5s ease",
        "&:hover": {
      transform: "scale(1.02)",
      boxShadow: "0 4px 20px rgba(0,0,0,0.3)",
    },
                            
          }}
          
        >
          
          {p.posterUrl && (
            <img
              src={fotoUrl+"/"+p.posterUrl}
              alt={p.address}
              style={{
                width: "820px",      
                height: "600px",      
                objectFit: "cover",   
                borderRadius: "8px",
              }}
            />  
          )}
          <Box  sx={{
            color:"white"
          }}>
            <h2 style={{ margin: "0 0 8px 0" }}>{p.address}</h2>
            <p style={{ margin: "4px 0" }}>Кімнат: {p.amountOfRooms}</p>
            <p style={{ margin: "4px 0" }}>Ціна за ніч: {p.pricePerNight} грн</p>
          </Box>
          
        </Box>

           ))}
           
          </div>
           </Link> 
            </>

        )

}

export default HousePage;