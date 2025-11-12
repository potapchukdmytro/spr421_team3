import { configureStore } from "@reduxjs/toolkit";
import { HousesApi } from "./HouseAPI";
export const store = configureStore({
    reducer: {
      [HousesApi.reducerPath]: HousesApi.reducer
    },
    middleware: (getDefaultMiddleware) => 
        getDefaultMiddleware().concat(HousesApi.middleware),
        
});


export type RootState = ReturnType<typeof store.getState>

export type AppDispatch = typeof store.dispatch