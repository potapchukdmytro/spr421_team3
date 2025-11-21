import { useAppSelector  } from "../../hooks/hooks";
import Typography from "@mui/material/Typography";
import Card from "@mui/material/Card";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import FormControl from "@mui/material/FormControl";
import FormLabel from "@mui/material/FormLabel";
import TextField from "@mui/material/TextField";
import { useState, type ChangeEvent  } from "react";
import { useCreateHouseMutation } from "../../store/services/houseApi";
import type { CreateHouse } from "./types";
import { useFormik } from "formik";
import ImageIcon from "@mui/icons-material/Image";
import styled from "@emotion/styled";

const VisuallyHiddenInput = styled("input")({
    clip: "rect(0 0 0 0)",
    clipPath: "inset(50%)",
    height: 1,
    overflow: "hidden",
    position: "absolute",
    bottom: 0,
    left: 0,
    whiteSpace: "nowrap",
    width: 1,
});

const Housebooking = ()=> {
  const user = useAppSelector((state) => state.auth.user);
  const [posterFile, setPosterFile] = useState<File | null>(null);
  const [createHouse] = useCreateHouseMutation();

    const handlePosterFileChange = (event: ChangeEvent<HTMLInputElement>) => {
    const files = event.target.files;
    if (files && files.length > 0) {
        setPosterFile(files[0]);
    }
    };

    const initValues: CreateHouse = {
        address: "",
        amountOfRooms: "",
        PricePerNight: ""
    };

  const handleSubmit = async (values: CreateHouse) => {
        const formData = new FormData();

        formData.append("address", values.address);
        formData.append("amountOfRooms", values.amountOfRooms);
        formData.append("pricePerNight", values.PricePerNight);
        formData.append("ownerId", user?.id || "");
        if (posterFile) {
            formData.append("posterFile", posterFile);
        }
        const response = await createHouse(formData);
        console.log("House created:", response);
    };

    const formik = useFormik({
        initialValues: initValues,
        onSubmit: handleSubmit,
    });

  return(
    <>
    <Box >

        <Card variant="outlined" sx={{ backgroundColor: "#31302F" ,color:"white"}} >
        <Typography
            component="h1"
            variant="h4"
            color="white"
            sx={{
                width: "100%",
                fontSize: "clamp(2rem, 10vw, 2.15rem)",
            }}>
            Додавання житла
            </Typography>
            <Box
            onSubmit={formik.handleSubmit}
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
                    <FormLabel htmlFor="address">Адреса</FormLabel>
                        <TextField
                            name="address"
                            type="text"
                            placeholder="Опис"
                            id="address"
                            fullWidth
                            variant="outlined"
                            value={formik.values.address}
                            onChange={formik.handleChange}
                        />
                </FormControl>
                <FormControl>
                    <FormLabel htmlFor="amountOfRooms">Кількість кімнат</FormLabel>
                        <TextField
                            name="amountOfRooms"
                            type="text"
                            placeholder="Опис"
                            id="amountOfRooms"
                            fullWidth
                            variant="outlined"
                            value={formik.values.amountOfRooms}
                            onChange={formik.handleChange}
                        />
                </FormControl>
                <FormControl>
                    <FormLabel htmlFor="PricePerNight">Ціна за одну ніч</FormLabel>
                        <TextField
                            name="PricePerNight"
                            type="text"
                            placeholder="Опис"
                            id="PricePerNight"
                            fullWidth
                            variant="outlined"
                            value={formik.values.PricePerNight}
                            onChange={formik.handleChange}
                        />
                </FormControl>
                <FormControl>
                    <Button
                        color="secondary"
                        component="label"
                        role={undefined}
                        variant="contained"
                        tabIndex={-1}
                        startIcon={<ImageIcon />}
                    >
                    Завантажити фото будинку
                    <VisuallyHiddenInput
                        accept="image/*"
                        type="file"
                        onChange={handlePosterFileChange}
                    />
                    </Button>
                    {posterFile && (
                        <Box
                            display="flex"
                            width="100%"
                            justifyContent="center"
                        >
                            <Box
                                borderRadius="15px"
                                height="200px"
                                component="img"
                                src={URL.createObjectURL(posterFile)}
                            />
                        </Box>
                    )}
                </FormControl>
                <Button type="submit" fullWidth variant="contained">
                    додати будинок
                </Button>
            </Box>
        </Card>
    </Box>
    </>
  )     
}
    
export default Housebooking