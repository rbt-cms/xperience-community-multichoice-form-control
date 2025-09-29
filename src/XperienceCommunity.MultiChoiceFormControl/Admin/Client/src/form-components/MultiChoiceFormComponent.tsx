import React, { useState } from "react";
import { FormComponentProps } from "@kentico/xperience-admin-base";
import { FormItemWrapper, Checkbox } from "@kentico/xperience-admin-components";

interface MultiChoiceProps extends FormComponentProps {
  options: MultiChoiceOptionItem[] | null;
  errorMessage: string | null;
  optionsValueSeparator: string | null;
}

export interface MultiChoiceOptionItem {
  value: string;
  text: string;
}

export const MultiChoiceFormComponent: React.FC<MultiChoiceProps> = (props) => {
  const selectedValues = (
    props.value ? props.value.split(props.optionsValueSeparator) : []
  ) as string[];
  const separator = props.optionsValueSeparator
    ? props.optionsValueSeparator
    : ",";
  const handleChange = (optionValue: string) => {
    let newValues;
    if (selectedValues.includes(optionValue)) {
      newValues = Array.isArray(selectedValues)
        ? selectedValues.filter((value) => value !== optionValue)
        : [];
    } else {
      newValues = [...selectedValues, optionValue];
    }
    if (props.onChange) {
      props.onChange(Object.values(newValues).join(separator).toString());
    }
  };

  return (
    <FormItemWrapper
      label={props.label}
      explanationText={props.explanationText}
      invalid={props.invalid}
      validationMessage={props.validationMessage}
      markAsRequired={props.required}
      labelIcon={props.tooltip ? "xp-i-circle" : undefined}
      labelIconTooltip={props.tooltip}
    >
      <div
        style={{
          display: "grid",
          gridTemplateColumns: "repeat(4, 1fr)", // 4 equal-width columns
          gap: "16px", // Space between cells
          marginTop: "8px", // Space below label
          padding: "8px", // Padding around grid
        }}
      >
        {props?.options?.length ? (
          props.options.map((option) => (
            <div
              key={option.value}
              style={{
                display: "flex",
                alignItems: "center", // Center checkbox and label vertically
                padding: "8px", // Padding inside cell
              }}
            >
              <Checkbox
                checked={selectedValues.includes(option.value)}
                onChange={() => handleChange(option.value)}
                label={option.text}
              />
            </div>
          ))
        ) : (
          <div
            style={{
              gridColumn: "span 4", // Span all 4 columns
              textAlign: "center",
              color: "#666",
              padding: "16px",
            }}
          >
            No options available
          </div>
        )}
      </div>
    </FormItemWrapper>
  );
};
