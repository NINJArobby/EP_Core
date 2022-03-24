import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function FIMANAGE() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'Fimi Application - Management'})}</PageTitle>
        FIMI APPLICATION - MANAGEMENT
    </div>
}