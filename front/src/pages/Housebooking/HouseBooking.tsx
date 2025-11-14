import { useAppSelector  } from "../../hooks/hooks";
import { fotoUrl} from '../../env';
import CssBaseline from "@mui/material/CssBaseline";
import Typography from "@mui/material/Typography";
import Card from "@mui/material/Card";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import FormControl from "@mui/material/FormControl";
import FormLabel from "@mui/material/FormLabel";
import TextField from "@mui/material/TextField";
import { useState } from "react";
import { useCreateBookingMutation } from "../../store/services/bookingApi";

const Housebooking = ()=> {
  const house = useAppSelector((state) => state.home);
  const user = useAppSelector((state) => state.auth.user);
  const [createBooking] = useCreateBookingMutation();
  const [rezevationDate, setRezevationDate] = useState<Date>(new Date());

  const convertDate = (date: Date) => {
        const iso = date.toISOString().substring(0, 10);
        return iso;
  };

  const TotalPrice = (startDate: Date, endDate: Date, pricePerNight: number) => {
        const timeDiff = Math.abs(endDate.getTime() - startDate.getTime());
        const diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24)); 
        return diffDays * pricePerNight;
  }

  const handleSubmit = async () => {
        const formData = new FormData();

        formData.append("houseId", house.ownerId);
        formData.append("userId", user?.id || "");
        formData.append("endDate", rezevationDate ? convertDate(rezevationDate) : "");
        formData.append("totalPrice", TotalPrice(new Date(), rezevationDate, house.pricePerNight).toString());
        

        const result = await createBooking(formData);
        console.log("Booking Result:", result);
    };

  return(
    <div className="flex items-center gap-6 p-6 rounded-2xl shadow-md **bg-black**">
      

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

      <CssBaseline enableColorScheme />
      <Card variant="outlined">
      <Typography
          component="h1"
          variant="h4"
          sx={{
              width: "100%",
              fontSize: "clamp(2rem, 10vw, 2.15rem)",
          }}>
          Бронювання житла
        </Typography>
        <Box
          onSubmit={handleSubmit}
          component="form"
          noValidate
          sx={{
              display: "flex",
              flexDirection: "column",
              width: "100%",
              gap: 2,
          }}>
            <FormControl>
                <FormLabel htmlFor="releaseDate">
                    Дата до якої бронювати
                </FormLabel>
                <TextField
                    name="releaseDate"
                    type="date"
                    placeholder="Дата виходу"
                    id="releaseDate"
                    fullWidth
                    variant="outlined"
                    onChange={(e) => setRezevationDate(new Date(e.target.value))}
                />
            </FormControl>
            <Button type="submit" fullWidth variant="contained">
                Забронювати
            </Button>
        </Box>
      </Card>

    </div>
  )     
}
    
export default Housebooking