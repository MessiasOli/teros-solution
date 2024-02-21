export function safeTextExponential(data: Data, decimalPlaces = 2) {
  let safeText = safeTextFixed(data, decimalPlaces);
  if (safeText !== "-") {
    safeText = Number(safeText).toExponential(decimalPlaces);
  }
  return safeText;
}

export function safeTextFixed(data: Data, decimalPlaces = 2) {
  if (data == null || data == undefined) {
    return "-";
  }
  const numberData = Number(data);
  if (isFinite(numberData)) {
    return numberData.toFixed(decimalPlaces);
  }
  return data;
}

export function safeText(data: Data) {
  if (data == null || data == undefined) {
    return "-";
  }
  return data;
}

export type Data = number | string | undefined | null;
