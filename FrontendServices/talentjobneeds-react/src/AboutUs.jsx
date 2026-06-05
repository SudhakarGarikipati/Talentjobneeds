import React from 'react'
import User from './User'

export const AboutUs = () => {
  return (
    <div><p className='text-center font-bold'>AboutUs, This is jobsearch app, thanks for you suporters.</p>
        <div className='my-1 border-solid border-black border'>
            <User loginName="JyothsnaGarikipati"/>
            <User loginName="SudhakarGarikipati"/>
        </div>
    </div>
  )
}
