import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../_metronic/layout/core";

export function FimiAgents() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'FIMI Agents'})}</PageTitle>
        FIMI
    </div>
}