import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { apiUrl } from '../env';
import type { ServiceResponse } from './services/types';

export const HousesApi = createApi({
    baseQuery: fetchBaseQuery({
        baseUrl: apiUrl
    }),
    tagTypes: ['houses'],
    reducerPath: "house",
    endpoints: (build) => ({
        getHouses: build.query<ServiceResponse, null>({
            query: () => ({
                url: 'house',
                method: 'get'
            }),
            providesTags: ['houses']
        })
   })
});

export const { useGetHousesQuery } = HousesApi;