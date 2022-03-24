import React from "react";
import {useIntl} from "react-intl";
import {PageTitle} from "../../_metronic/layout/core";

export function CIBAgents() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'CIB Agents'})}</PageTitle>
        cib
    </div>
}