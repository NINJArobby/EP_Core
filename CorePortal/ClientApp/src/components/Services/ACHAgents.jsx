import React from 'react';
import {PageTitle} from "../../_metronic/layout/core";
import {useIntl} from 'react-intl'

export function ACHAgents() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'ACH Agents'})}</PageTitle>
        ghoooollll
    </div>
}