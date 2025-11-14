import { useAppSelector  } from "../../hooks/hooks";
import { fotoUrl} from '../../env';

import Typography from "@mui/material/Typography";
import Card from "@mui/material/Card";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import FormControl from "@mui/material/FormControl";
import FormLabel from "@mui/material/FormLabel";
import TextField from "@mui/material/TextField";
import { useState } from "react";
import { useCreateBookingMutation } from "../../store/services/bookingApi";
import "./HouseBooking.css";

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
    
      <>

<Box sx={{position: "relative",width: 1200, height: 810   }}>
  <Box
  component="img"
  src={fotoUrl + "/" + house.posterUrl}
  sx={{
    width: "1200px",        
    height: "830px",   



    "&:hover": {
      opacity: 0.8,    
    },
  }}
/>
</Box>


<div>
<Box sx={{ display: "flex", flexDirection: "column", marginLeft:"1400px",marginTop:"-330px", position: "absolute", }}>
  <Typography variant="h6">{house.address}</Typography>
  <Typography variant="h6">Кімнат: {house.amountOfRooms}</Typography>
  <Typography variant="h6">Ціна за ніч: {house.pricePerNight}</Typography>
</Box>
</div>
<Box sx={{  flexDirection: "column", marginLeft:"1400px",marginTop:"-210px",position: "absolute",}}>

      <Card variant="outlined" sx={{ backgroundColor: "#31302F" ,color:"white"}} >
      <Typography
          component="h1"
          variant="h4"
          color="white"
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
              color:"white",
              width: "100%",
              gap: 2,
          }}>
            <FormControl>
                <FormLabel htmlFor="releaseDate" sx={{color:"white"}}>
                    Дата до якої бронювати
                </FormLabel>
                <TextField sx={{color:"white"}}
                    name="releaseDate"
                    type="date"
                    placeholder="Дата виходу"
                    id="releaseDate"
                    fullWidth
                    variant="outlined"
                    onChange={(e) => setRezevationDate(new Date(e.target.value))}
                     InputProps={{
                    sx: {
                          color: "white", 
                          "&::placeholder": { color: "lightgray" }, 
                          },
    }}
                />
            </FormControl>
            <Button type="submit" fullWidth variant="contained">
                Забронювати
            </Button>
        </Box>
      </Card>
</Box>
      


    </>
  )     
}
    
export default Housebooking