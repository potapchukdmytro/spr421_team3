import { configureStore } from "@reduxjs/toolkit";
import { houseApi } from "./services/houseApi";

export const store = configureStore({
    reducer: {
      [houseApi.reducerPath]: houseApi.reducer,
    },
    middleware: (getDefaultMiddleware) => 
        getDefaultMiddleware()
                .concat(houseApi.middleware),
        
});


export type RootState = ReturnType<typeof store.getState>

export type AppDispatch = typeof store.dispatch