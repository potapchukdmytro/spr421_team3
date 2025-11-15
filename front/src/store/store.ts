import { configureStore } from "@reduxjs/toolkit";
import { HousesApi } from "./HouseAPI";
import houseslice from "../store/slices/houseSlice";
import authReducer from "./slices/authSlice";
import { bookingApi } from "./services/bookingApi";

export const store = configureStore({
    reducer: {
      auth: authReducer,
      [HousesApi.reducerPath]: HousesApi.reducer,
      [bookingApi.reducerPath]: bookingApi.reducer,
      home : houseslice,

    },
    middleware: (getDefaultMiddleware) => 
        getDefaultMiddleware()
        .concat(HousesApi.middleware).concat(bookingApi.middleware)
});


export type RootState = ReturnType<typeof store.getState>

export type AppDispatch = typeof store.dispatch