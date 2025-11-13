import { useAppSelector  } from "../../store/hooks";
import { fotoUrl} from '../../env';


const Housebooking = ()=> 
    {
         const house = useAppSelector((state) => state.home);
        return(
    <div className="flex items-center gap-6 p-6 rounded-2xl shadow-md bg-white max-w-3xl mx-auto">
      

      <img 
        src={fotoUrl+"/" + house.posterUrl} 
        
      />


      <div className="flex flex-col">
        <h2 className="text-xl font-bold mb-2">{house.address}</h2>
        <p className="text-gray-600">
          Це короткий опис про фото: що це, чому важливо, які особливості,
          або будь-яка інша інформація, яку ти хочеш показати.
        </p>
      </div>

    </div>
        )     
    }
    export default Housebooking