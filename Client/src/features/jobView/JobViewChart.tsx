import { stat } from 'fs';
import React, { useState } from 'react';
import { Chart } from "react-google-charts";
import { useSelector } from 'react-redux';
import { setJobViews, getJobViewsAsync } from './JobViewSlice'
import { useAppSelector, useAppDispatch } from '../../app/hooks';
import styles from './JobView.module.css';

export function JobViewChart() {
  const jobViewData = useSelector((state: any) => state.jobViews.views);
  const dispatch = useAppDispatch();

  var fromDate: string;
  var toDate: string;
  const options = {
    title: "Cumulative job views vs. prediction",
    vAxis: { title: "Cups" },
    hAxis: { title: "Month" },
    seriesType: "line",
    series: { 2: { type: "bars" } },

  };

  function handleChangeFromDate(e: React.FormEvent<HTMLInputElement>) {
    fromDate = e.currentTarget.value;
  }

  function handleChangeToDate(e: React.FormEvent<HTMLInputElement>) {
    toDate = e.currentTarget.value;
  }

  return (
    <div>
      <div className={styles.row}>
        <label>
          From:
          <input type="text" name="fromDate" onChange={handleChangeFromDate} />
        </label>
        <label>
          To:
          <input type="text" name="toDate" onChange={handleChangeToDate} />
        </label>
      </div>
      <button
        className={styles.asyncButton}
        onClick={() => {
          dispatch(getJobViewsAsync({fromDate, toDate}))
        }}
      >
        Get Data
      </button>
      <div className={styles.row}>
        <Chart
          chartType="ComboChart"
          data={jobViewData}
          options={options}
          width="100%"
          height="400px"
          legendToggle

        />
      </div></div>
  )
}


