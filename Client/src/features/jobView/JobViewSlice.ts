import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit'
import { RootState, AppThunk } from '../../app/store';
import { fetchJobViewData } from './jobViewAPI';

export const getJobViewsAsync = createAsyncThunk(
    'jobView/jobViews',
    async ({ fromDate, toDate }: { fromDate: string, toDate: string }) => {
        var response = await fetchJobViewData(fromDate, toDate);
        return response;
    }
);

export const jobViewSlice = createSlice({
    name: 'jobView',
    initialState: {
        views: [
            [
                "Date",
                "Jobs views",
                "Predicted job views",
                "Active jobs"
            ],
            [],
        ]
    },
    reducers: {
        setJobViews: (state, action) => {
            state.views = [];
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(getJobViewsAsync.pending, (state) => {
                state.views = [];
            })
            .addCase(getJobViewsAsync.fulfilled, (state, action) => {
                var jobViewsJson = JSON.parse(action.payload);
                var jobViews = [[
                    "Date",
                    "Jobs views",
                    "Predicted job views",
                    "Active jobs"
                ]];
                jobViewsJson.forEach((element: any) => {
                    jobViews.push([element.JobViewDate, element.JobsViews, element.PredictedJobViews, element.ActivesJobs])
                });
                state.views = jobViews;
            })
            .addCase(getJobViewsAsync.rejected, (state) => {
                state.views = [];
            });
    },
})

// Action creators are generated for each case reducer function
export const { setJobViews } = jobViewSlice.actions
export const selectCount = (state: RootState) => state.jobViews.views;

export default jobViewSlice.reducer