import { useGetHousesQuery } from "../../store/HouseAPI";
import { fotoUrl} from '../../env';
import './HousePage.css';

const HousePage = () =>{

const {data} = useGetHousesQuery(null)

console.log(fotoUrl+"/"+data?.payload[0].posterUrl)
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
            
           {data?.payload.map((p: House,index:number)=>(
           
        <div 
        
          key={index}
          style={{
                display: "flex",
                flexDirection: "row",
                width: "100%",            // повна ширина контейнера
                padding: "40px",
                border: "1px solid #ccc",
                borderRadius: "8px",
                boxShadow: "0 2px 8px rgba(0,0,0,0.1)",
                gap: "16px",
                alignItems: "flex-start", // вирівнювання зверху
                marginBottom: "24px",
                boxSizing: "border-box",
                overflow: "hidden",  
                            
          }}
          
        >
          {p.posterUrl && (
            <img
              src={fotoUrl+"/"+p.posterUrl}
              alt={p.address}
              style={{
                width: "1000px",       // ширина картинки
                height: "550px",      // висота картинки
                objectFit: "cover",   // зберігає пропорції і обрізає лишнє
                borderRadius: "8px",
              }}
            />
          )}
          <div>
            <h2 style={{ margin: "0 0 8px 0" }}>{p.address}</h2>
            <p style={{ margin: "4px 0" }}>Кімнат: {p.amountOfRooms}</p>
            <p style={{ margin: "4px 0" }}>Ціна за ніч: {p.pricePerNight} грн</p>
          </div>
          
        </div>

           ))}
           
           
            </>
    
        )

}
export default HousePage;