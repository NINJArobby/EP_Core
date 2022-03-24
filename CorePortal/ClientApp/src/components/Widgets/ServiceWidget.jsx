import React, {useEffect, useRef, useState} from 'react';
import {KTSVG} from "../../_metronic/helpers";
import Lottie from "lottie-react";
import gearAnimation from '../../lotties/lottie-gears'
import axios from "axios";

export function ServiceWidget(props) {
    // Declare a new state variable, which we'll call "count"  
    const [wheight, setwheight] = useState(props.height);
    const [wcolor, setcolor] = useState(props.color);
    const [wheader, setheader] = useState(props.header);
    const [mwheader, setmwheader] = useState('');

    const lottieRef = useRef();
    let _stat = '';
    const triggerAgent = (status) => {
        _stat = status;
        switch (status) {
            case 'pause':
                setmwheader('stopped');
                lottieRef.current.pause();
                break;
            case 'stop':
                setmwheader('stopped');
                lottieRef.current.pause();
                break;
            case 'start':
                setmwheader('running');
                lottieRef.current.play();
                break;
        }
    }

    const checkStatus = (props, config, bodyParameters) => {
        let name = props.serviceName;
        //do check here
        //network call to get state of agents
        axios.post(
            'http://localhost:8000/api/v1/get_token_payloads',
            bodyParameters,
            config
        ).then(console.log)
            .catch(console.log);
    }

    useEffect(() => {
        setmwheader('fetching');
        const config = {
            headers: {Authorization: `Bearer `}
        };
        const bodyParameters = {
            key: "value"
        };
        checkStatus(props, config, bodyParameters);
    });


    return <div>
        <div className='col-md-8 card-xl-stretch mb-xl-4'>
            <div className='card card-xl-stretch mb-xl-4'>
                <div className={`card-header border-0 py-5 bg-${wcolor}`}>
                    <h3 className='card-title align-items-start flex-column'>
                        <span className='fw-bolder mb-2 text-dark'>{wheader}</span>
                        <span className='text-muted fw-bold fs-7'>{mwheader}</span>
                    </h3>
                    <div className='card-toolbar'>
                        {/* begin::Menu */}
                        <button type='button' onClick={() => {
                            triggerAgent('pause')
                        }}
                                className='btn btn-sm btn-icon btn-color-primary btn-active-light-primary'
                                data-kt-menu-trigger='click'
                                data-kt-menu-placement='bottom-end'
                                data-kt-menu-flip='top-end'>
                            <KTSVG path='/media/icons/duotune/general/gen024.svg' className='svg-icon-4'/>
                        </button>
                        <button type='button' onClick={() => {
                            triggerAgent('start')
                        }}
                                className='btn btn-sm btn-icon btn-color-primary btn-active-light-primary'
                                data-kt-menu-trigger='click'
                                data-kt-menu-placement='bottom-end'
                                data-kt-menu-flip='top-end'>
                            <KTSVG path='/media/icons/duotune/general/gen024.svg' className='svg-icon-4'/>
                        </button>
                    </div>
                    <div className="card-body">
                        <Lottie lottieRef={lottieRef} animationData={gearAnimation} loop={true} autoplay={false}/>
                    </div>
                </div>
            </div>
        </div>
    </div>
}


