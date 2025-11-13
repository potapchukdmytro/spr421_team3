import { configureStore } from "@reduxjs/toolkit";
import { HousesApi } from "./HouseAPI";
import houseslice from "../store/slices/houseSlice";
export const store = configureStore({
    reducer: {
      [HousesApi.reducerPath]: HousesApi.reducer,
      home : houseslice,

    },
    middleware: (getDefaultMiddleware) => 
        getDefaultMiddleware().concat(HousesApi.middleware),

        
});


export type RootState = ReturnType<typeof store.getState>

export type AppDispatch = typeof store.dispatch