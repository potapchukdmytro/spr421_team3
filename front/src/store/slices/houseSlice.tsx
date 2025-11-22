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
    name: "home",
    initialState: Houses,
    reducers: {
        housebookingget(state, action: PayloadAction<null>) {

            },
          houseset(state, action: PayloadAction<House>) {
           state.address = action.payload.address;
           state.amountOfRooms = action.payload.amountOfRooms;
           state.pricePerNight = action.payload.pricePerNight;
           state.posterUrl = action.payload.posterUrl;
           state.isAvialable = action.payload.isAvialable;
           state.ownerId = action.payload.ownerId;
           
            }


        },

    
});

export const { housebookingget,houseset } = HouseBooks.actions;
export default HouseBooks.reducer;
