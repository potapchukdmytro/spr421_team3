import { createSlice, type PayloadAction } from "@reduxjs/toolkit";
import type { House } from "./types";

const  Houses : House = {
  address: "",
  amountOfRooms: 0,
  pricePerNight: 0,
  posterUrl: "",
  isAvialable: false,
  ownerId: ""
};

const HouseBooks = createSlice({
    name: "house",
    initialState: Houses,
    reducers: {
        housebookingget(state, action: PayloadAction<string>) {
           
            }


        },

    
});

export const { housebookingget } = HouseBooks.actions;
export default HouseBooks.reducer;
