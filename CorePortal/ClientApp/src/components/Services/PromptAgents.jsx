import React from 'react';
import {useIntl} from 'react-intl'
import {PageTitle} from '../../_metronic/layout/core'
import {ServiceWidget} from "../Widgets/ServiceWidget";

export function PromptAgents() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'Prompt Agents'})}</PageTitle>

        {/* begin::Row */}
        <div className='row gy-5 g-xxl-4'>
            <div className='col-xxl-4'>
                <ServiceWidget color='' wheight='200p' header='Email Agent' serviceName='email'/>
            </div>
            <div className='col-xxl-4'>
                <ServiceWidget color='' wheight='200p' header='Infobip Agent' serviceName='infobip'/>
            </div>
            <div className='col-xxl-4'>
                <ServiceWidget color='' wheight='200p' header='RouteMob Agent' serviceName='route'/>
            </div>
            <div className='col-xxl-4'>
                <ServiceWidget color='' wheight='200p' header='Spooler Agent' serviceName='spooler'/>
            </div>
        </div>
        {/* end::Row */}

    </div>
}