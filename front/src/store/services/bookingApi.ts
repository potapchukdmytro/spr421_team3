import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { apiUrl } from '../../env';
import type { ServiceResponse } from './types';

export const bookingApi = createApi({
    baseQuery: fetchBaseQuery({
        baseUrl: apiUrl,
        headers: {
            "Authorization": `Bearer ${localStorage.getItem("token")}`
        }
    }),
    tagTypes: ['booking'],
    reducerPath: 'booking',
    endpoints: (build) => ({
        createBooking: build.mutation<ServiceResponse, FormData>({
            query: (formData) => ({
                url: 'booking',
                method: 'post',
                body: formData
            }),
            invalidatesTags: ['booking']
        })
    })
});

export const { useCreateBookingMutation } = bookingApi;