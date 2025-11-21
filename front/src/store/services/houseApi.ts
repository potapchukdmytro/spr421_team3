import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { apiUrl } from '../../env';
import type { ServiceResponse } from './types';

export const houseApi = createApi({
    baseQuery: fetchBaseQuery({
        baseUrl: apiUrl,
        headers: {
            "Authorization": `Bearer ${localStorage.getItem("token")}`
        }
    }),
    tagTypes: ['house'],
    reducerPath: 'house',
    endpoints: (build) => ({
        getHouses: build.query<ServiceResponse, null>({
            query: () => ({
                url: 'house',
                method: 'get'
            }),
            providesTags: ['house']
        }),
        createHouse: build.mutation<ServiceResponse, FormData>({
            query: (formData) => ({
                url: 'house',
                method: 'post',
                body: formData
            }),
            invalidatesTags: ['house']
        })
    })
});

export const { useGetHousesQuery, useCreateHouseMutation } = houseApi;